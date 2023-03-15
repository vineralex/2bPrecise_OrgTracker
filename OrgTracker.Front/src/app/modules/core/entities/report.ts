/**
 * Data transfer object for a report entity.
 */
export interface Report { 
    /**
     * The unique identifier of the report.
     */
    id?: number;
    /**
     * The text content of the report.
     */
    text?: string;
    /**
     * The date the report was submitted.
     */
    date?: Date;
}