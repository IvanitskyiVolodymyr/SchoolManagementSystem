import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EntityWithRole } from '../models/Users/entityWithRole';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private prefix = "/users";
  constructor(
    private httpService: HttpClientService
  ) { }

  public getEntityIdWithRole(userId: number, roleId: number) : Observable<EntityWithRole> {
    return this.httpService.get<EntityWithRole>(
      `${this.prefix}/user-with-role`,
       new HttpParams().set('userId', userId).set('roleId',roleId));
  }

  public getClassIdByStudentId(studentId: number) : Observable<number> {
    return this.httpService.get<number>(
      `${this.prefix}/get-class-id`,
       new HttpParams().set('studentId', studentId));
  }
}
