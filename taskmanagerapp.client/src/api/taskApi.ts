import type { Task, CreateTaskRequest } from "../types/Task";

const BASE_URL = "http://localhost:8080/api/tasks";

export async function getTasks(): Promise<Task[]> {
    const response = await fetch(BASE_URL);

    if (!response.ok) {
        // Try to read error body safely
        let message = "Failed to fetch tasks";
        try {
            const data = await response.json();
            message = data?.message || message;
        } catch {
            // ignore JSON parse errors
        }
        throw new Error(message);
    }

    return await response.json();
}


export async function createTask(task: CreateTaskRequest): Promise<void> {
    const res = await fetch(BASE_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
    });

    if (!res.ok) {
        let errors: string[] = ["Something went wrong, details are not correct!"];

        try {
            const data = await res.json();

            if (Array.isArray(data?.errors)) {
                errors = data.errors;
            } else if (data?.message) {
                errors = [data.message];
            }
        } catch {
            // fallback if not JSON
        }

        throw errors; // This is important to return the right type for error handling in the form.
    }
}