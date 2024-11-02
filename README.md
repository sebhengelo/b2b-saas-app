# B2B SaaS Application

This project is a B2B SaaS application with a simple login screen (credentials: admin/admin). When you log in, you will see an application with a horizontal navbar, a sidebar, and a content area on the right. The application uses Preline standards.

## Project Setup

### Frontend

1. Navigate to the `frontend` directory:
   ```sh
   cd frontend
   ```

2. Install the dependencies:
   ```sh
   npm install
   ```

3. Start the development server:
   ```sh
   npm run dev
   ```

### Backend

1. Navigate to the `backend` directory:
   ```sh
   cd backend
   ```

2. Restore the dependencies:
   ```sh
   dotnet restore
   ```

3. Build the solution:
   ```sh
   dotnet build B2BSaaSApp.sln
   ```

4. Start the backend server:
   ```sh
   dotnet run --project B2BSaaSApp.csproj
   ```

## Usage Instructions

### Home Page

- After logging in, you will see the Home page with the message "Hello, world!".

### Insights Page

- Navigate to the Insights page using the menu.
- The Insights page contains a table with columns for Title, Source, and Date.
- The table is filled with some dummy data.
- There is a Create button above the table that allows you to add a new Insight to the table.

## Running the Docker Stack

1. Make sure you have Docker and Docker Compose installed on your machine.

2. Navigate to the root directory of the project.

3. Start the Docker stack:
   ```sh
   docker-compose up
   ```

4. The Docker stack includes a PostgreSQL instance and a Langchain instance. The PostgreSQL instance is initialized with a vector table to store embeddings.

5. The application connects to a GPT instance using an OpenAI API key.
