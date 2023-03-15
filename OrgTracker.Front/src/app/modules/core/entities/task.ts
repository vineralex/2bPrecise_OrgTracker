/**
 * Data transfer object for a task entity.
 */
export interface Task { 
    /**
     * The unique identifier of the task.
     */
    id?: number;
    /**
     * The text content of the task.
     */
    text?: string;
    /**
     * The date on which the task was assigned.
     */
    assignedDate?: Date;
    /**
     * The due date of the task.
     */
    dueDate?: Date;
}