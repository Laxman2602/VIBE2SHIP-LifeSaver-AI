from fastapi import FastAPI
from fastapi.responses import FileResponse
from pydantic import BaseModel
from google import genai
import requests
import os

app = FastAPI(title="Life Saver AI Gateway")

# 1. Initialize the Google Gen AI Client
# Ensure you set the GEMINI_API_KEY environment variable in Render!
client = genai.Client(api_key=os.environ.get("GEMINI_API_KEY"))

# Use the environment variable for the C# backend URL
C_SHARP_BACKEND_URL = os.environ.get("BACKEND_URL", "http://localhost:5188")

# --- THE TOOLS ---
def get_my_tasks():
    """Gets the user's current tasks from the database."""
    try:
        response = requests.get(f"{C_SHARP_BACKEND_URL}/api/tasks", timeout=5)
        return response.json()
    except Exception as e:
        print(f"DEBUG: Error fetching tasks: {e}")
        return {"error": "Could not reach database."}

def add_new_task(title: str, description: str, deadline: str, priority: str, estimatedMinutes: int):
    """Creates a new task in the database."""
    if "T" not in deadline:
        deadline = f"{deadline}T09:00:00"
    
    payload = {
        "title": title,
        "description": description,
        "deadline": deadline,
        "priority": priority,
        "estimatedMinutes": estimatedMinutes
    }
    
    try:
        response = requests.post(f"{C_SHARP_BACKEND_URL}/api/tasks", json=payload, timeout=5)
        print(f"DEBUG: C# Server Responded with {response.status_code}")
        return {"status": "success"}
    except Exception as e:
        print(f"DEBUG: Python Connection Error: {e}")
        return {"error": str(e)}

# 2. Endpoints
class ChatRequest(BaseModel):
    message: str

@app.post("/api/chat")
async def chat_with_gemini(request: ChatRequest):
    try:
        # Using the highly stable Flash 8b model
        response = client.models.generate_content(
            model='gemini-1.5-flash-8b', 
            contents=request.message,
            config={'tools': [get_my_tasks, add_new_task]}
        )
        return {"reply": response.text}
        
    except Exception as e:
        print(f"DEBUG: AI failed, falling back: {e}")
        # Manual fallback logic to keep the UI from hanging
        if "add" in request.message.lower() or "task" in request.message.lower():
             return {"reply": "AI Agent offline. Task not saved. Please check API quota."}
        return {"error": "AI Quota exhausted."}

@app.get("/")
async def get_dashboard():
    return FileResponse("index.html")