import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ClassSubjectGrade } from '../models/grades/classSubjectGrade';
import { SubjectGrade } from '../models/grades/subjectGrade';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class JournalService {

  private prefix = "/journal";
  constructor(
    private httpService: HttpClientService
  ) { }

  public GetAllGradesWithSubjectsForStudent(studentId: number ) : Observable<Array<SubjectGrade>> {
    return this.httpService.getFullRequest<Array<SubjectGrade>>(`${this.prefix}/GetAllGradesWithSubjectsForStudent`,
    new HttpParams().set('studentId', studentId))
    .pipe(
      map(
        (resp) => {
          return resp.body as Array<SubjectGrade>;
        })
    );
  }

  public GetAllFinalGradesByClassId(studentId: number, classId: number) : Observable<Array<ClassSubjectGrade>> {
    return this.httpService.getFullRequest<Array<ClassSubjectGrade>>(`${this.prefix}/GetAllFinalGradesByClassId`,
    new HttpParams().set('studentId', studentId).set('classId', classId))
    .pipe(
      map(
        (resp) => {
          return resp.body as Array<ClassSubjectGrade>;
        })
    );
  }

}
