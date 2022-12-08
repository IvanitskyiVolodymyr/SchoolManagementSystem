import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
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
    return this.httpService.getFullRequest<EntityWithRole>(
      `${this.prefix}/GetEntityIdWithRoleByUserId`,
       new HttpParams().set('userId', userId).set('roleId',roleId))
    .pipe(
      map(
        (resp) => {
          return resp.body as EntityWithRole;
        })
    );
  }
}
