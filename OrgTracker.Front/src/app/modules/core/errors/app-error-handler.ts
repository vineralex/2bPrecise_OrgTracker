import { NotFoundError } from './not-found-error';
import { BadInputError } from './bad-input-error';
import { ApplicationError } from './application-error';
import { ErrorHandler } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
    
    handleError(error: ApplicationError): void {
        switch(true) {
        case error instanceof BadInputError:
            alert('An unexpected error ocured');
            break;
        case error instanceof NotFoundError:
            alert('Not found error');
            break;
        default:
            alert('An unexpected error ocured');
            break;
        }
        console.log(error);
    }

}