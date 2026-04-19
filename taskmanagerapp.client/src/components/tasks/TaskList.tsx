import type { Task } from "../../types/Task";
import "../../styles/TaskStyles.css";

interface Props {
    tasks: Task[];
}

export default function TaskList({ tasks }: Props) {
    if (!tasks.length) {
        return <p>No tasks available.</p>;
    }

    return (
        <ul className="task-list">
            {tasks.map((task) => (
                <li key={task.id} className="task-item">
                    <div className="task-title">
                        {task.title} ({task.priority})
                    </div>

                    {task.description && <div>{task.description}</div>}
                    {task.dueDate && (
                        <div>
                            Due: {new Date(task.dueDate).toLocaleDateString("en-GB")}
                        </div>
                    )}
                </li>
            ))}
        </ul>
    );
}