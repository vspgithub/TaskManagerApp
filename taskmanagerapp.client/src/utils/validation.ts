import type { CreateTaskRequest } from "../types/Task";

export function validateTask(task: CreateTaskRequest): string[] {
    const errors: string[] = [];

    if (!task.title.trim()) {
        errors.push("Title is required");
    }

    if (task.title.length > 100) {
        errors.push("Title must be <= 100 characters");
    }

    if (task.description && task.description.length > 500) {
        errors.push("Description must be <= 500 characters");
    }

    if (task.dueDate) {
        const selected = new Date(task.dueDate);
        const today = new Date();
        today.setHours(0, 0, 0, 0);

        if (selected < today) {
            errors.push("Due date cannot be in the past");
        }
    }

    return errors;
}