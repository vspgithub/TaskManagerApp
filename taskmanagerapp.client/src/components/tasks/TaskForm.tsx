import { useState } from "react";
import type { CreateTaskRequest, Priority } from "../../types/Task";
import { validateTask } from "../../utils/validation";
import "../../styles/TaskStyles.css";
interface Props {
    onSubmit: (task: CreateTaskRequest) => Promise<void>;
}

export default function TaskForm({ onSubmit }: Props) {
    const [form, setForm] = useState<CreateTaskRequest>({
        title: "",
        description: "",
        dueDate: "",
        priority: "Low",
    });

    const [errors, setErrors] = useState<string[]>([]);

    const handleChange = <K extends keyof CreateTaskRequest>(
        field: K,
        value: CreateTaskRequest[K]
    ) => {
        setForm(prev => ({ ...prev, [field]: value }));
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        //Client Side Validations
        const clientErrors = validateTask(form);
        if (clientErrors.length) {
            setErrors(clientErrors);
            return;
        }

        try {
            await onSubmit(form);
            //Clear CreateTask form on success
            setErrors([]);
            setForm({
                title: "",
                description: "",
                dueDate: "",
                priority: "Low",
            });
        } catch (apiErrors: unknown) {
            // Handle API validation errors safely
            if (Array.isArray(apiErrors)) {
                setErrors(apiErrors);
            } else {
                setErrors(["Unexpected error occurred, Something went wrong.."]);
            }
        }
    };

    return (
       
        <form onSubmit={handleSubmit} className="task-form">
            <h2>Add Task</h2>

            <div className="form-group">
                <label>Title</label>
                <input
                    type="text"
                    placeholder="Enter title"
                    value={form.title}
                    onChange={(e) => handleChange("title", e.target.value)}
                />
            </div>

            <div className="form-group">
                <label>Description</label>
                <textarea
                    placeholder="Enter description"
                    value={form.description}
                    onChange={(e) => handleChange("description", e.target.value)}
                />
            </div>

            <div className="form-group">
                <label>Due Date</label>
                <input
                    type="date"
                    value={form.dueDate}
                    onChange={(e) => handleChange("dueDate", e.target.value)}
                />
            </div>

            <div className="form-group">
                <label>Priority</label>
                <select
                    value={form.priority}
                    onChange={(e) =>
                        handleChange("priority", e.target.value as Priority)
                    }
                >
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>
            </div>

            <button type="submit" className="submit-btn">
                Create Task
            </button>

            {/* Displaying Error in UI */}
            {errors.length > 0 && (
                <div className="error-box">
                    {errors.map((err, index) => (
                        <div key={index}>• {err}</div>
                    ))}
                </div>
            )}
        </form>
    );
}