/**
 * Data transfer object for an employee entity.
 */
export interface Employee {
    /**
     * The unique identifier of the employee.
     */
    id: number;
    /**
     * The first name of the employee.
     */
    firstName: string;
    /**
     * The last name of the employee.
     */
    lastName: string;
     /**
     * The position of the employee.
     */
    position: string;
    manager: Employee;
}