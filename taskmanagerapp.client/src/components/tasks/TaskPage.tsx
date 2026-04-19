import { useEffect, useState } from "react";
import { getTasks, createTask } from "../../api/taskApi";
import type { Task, CreateTaskRequest } from "../../types/Task";
import TaskList from "./TaskList";
import TaskForm from "./TaskForm";
import "../../styles/TaskStyles.css";

export default function TaskPage() {
    const [tasks, setTasks] = useState<Task[]>([]);
    const [loading, setLoading] = useState(true);

    //Loading Tasks from API
    const loadTasks = async () => {
        setLoading(true);
        try {
            const data = await getTasks();
            setTasks(data);
        } catch (err) {
            console.error("Error loading tasks", err);
        }
        setLoading(false);
    };

    //Run on page load
    useEffect(() => {
        const fetchTasks = async () => {
            setLoading(true);
            try {
                const data = await getTasks();
                setTasks(data);
            } finally {
                setLoading(false);
            }
        };

        fetchTasks();
    }, []);
    
    //Handle new task creation
    const handleCreate = async (task: CreateTaskRequest) => {
        await createTask(task);
        await loadTasks(); // refresh list after adding
    };

    return (
        <div className="page-container">
            <h1>Task Manager</h1>

            <div className="task-layout">
                {/* LEFT: Add Task Form */}
                <div className="task-form-section">
                    <TaskForm onSubmit={handleCreate} />
                </div>

                {/* RIGHT: View Task List */}
                <div className="task-list-section">
                    <h2>Task List</h2>

                    {loading ? <p>Loading...</p> : <TaskList tasks={tasks} />}
                </div>
            </div>
        </div>
    );
}




