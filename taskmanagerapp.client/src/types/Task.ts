export type Priority = "Low" | "Medium" | "High";

export interface Task {
    id: string;
    title: string;
    description?: string;
    dueDate?: string;
    priority: Priority;
}

export interface CreateTaskRequest {
    title: string;
    description?: string;
    dueDate?: string;
    priority: Priority;
}