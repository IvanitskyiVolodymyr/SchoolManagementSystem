import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
    return this.httpService.get<Array<SubjectGrade>>(`${this.prefix}/grades/${studentId}`);
  }

  public GetAllFinalGradesByClassId(studentId: number, classId: number) : Observable<Array<ClassSubjectGrade>> {
    return this.httpService.get<Array<ClassSubjectGrade>>(`${this.prefix}/final-grades/students/${studentId}/classes/${classId}`)
  }

}
