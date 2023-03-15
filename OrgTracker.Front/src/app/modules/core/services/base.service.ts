import { NotFoundError } from './../errors/not-found-error';
import { Injectable } from "@angular/core";
import { ApplicationError } from "@ot/errors/application-error";
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })
export class BaseService {
    protected handleError(error: Response) {
        if(error.status === 400) {
            return throwError(() =>new ApplicationError(error));
        }

        if(error.status === 404) {
            return throwError(() =>new NotFoundError(error));
        }

        return throwError(() =>new ApplicationError(error));
    }    
}