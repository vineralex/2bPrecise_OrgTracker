import { environment } from "@ot/env/environment";


export class Endpoints {
    static baseApiUrl = environment.baseApiUrl;

    static api = {
        employee: {
            employeeList: Endpoints.baseApiUrl + "Employee",
            employeeDetails: Endpoints.baseApiUrl + "Employee/{id}",
            getSubordinaries: Endpoints.baseApiUrl + "Employee/GetSubordinaries/{id}"
        },
        report: {
            reportsFromSubordinaries: Endpoints.baseApiUrl + "Report/GetReportsFromSubordinaries/{managerId}",
            create: Endpoints.baseApiUrl + "Report/{employeeId}/{managerId}"
        },
        task: {
            tasksAssignedToEmployee: Endpoints.baseApiUrl + "Task/GetTasksAssignedToEmployee/{employeeId}",
            create: Endpoints.baseApiUrl + "Task/{managerId}/{assignToId}"
        }
    }
}