# Life Saver AI - VIBE2SHIP Hackathon

## Project Overview
An agentic task management system designed to streamline productivity through natural language processing. The system uses a FastAPI gateway to orchestrate tool-calling to a C# backend.

## Architecture
- **Frontend:** HTML5 + Tailwind CSS (Dashboard)
- **Gateway:** FastAPI (Python) with Google Gemini AI integration
- **Backend:** ASP.NET Core MVC (C#)
- **Database:** SQLite

## How to Run Locally
1. **Backend:** Navigate to `lifesaver-backend/` and run `dotnet run`.
2. **Gateway:** Navigate to `lifesaver-ai-service/` and run `uvicorn main:app --port 8000 --reload`.
3. **Dashboard:** Open `http://localhost:8000` in your browser.

## Known Limitations
Due to free-tier API rate limits on the Google Gen AI platform, the AI tool-calling gateway may occasionally require a cooldown period. The core data persistence layer remains fully operational for manual task management.