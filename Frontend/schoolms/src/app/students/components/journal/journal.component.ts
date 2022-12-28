import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { map } from 'rxjs';
import { ClassSubjectGrade } from 'src/app/shared/models/grades/classSubjectGrade';
import { Grade } from 'src/app/shared/models/grades/grade';
import { SubjectGrade } from 'src/app/shared/models/grades/subjectGrade';
import { JournalService } from 'src/app/shared/services/journal.service';
import { UserService } from 'src/app/shared/services/user.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-journal',
  templateUrl: './journal.component.html',
  styleUrls: ['./journal.component.scss']
})
export class JournalComponent implements OnInit{

  public subjectsWithGrades: Array<SubjectGrade> = [] as Array<SubjectGrade>;
  public subjectsWithFinalGrades: Array<ClassSubjectGrade> = [] as Array<ClassSubjectGrade>;
  public maxCountOfGrades = 0;

  constructor(
    private journalService: JournalService,
    private router: Router,
    private userService: UserService,
    private store: Store) { }

  ngOnInit(): void {
    this.store.select(entityWithRole).pipe(
      map(x => {
        return x?.entityId;
      }),
      map(studentId => {
        this.getAllGrades(studentId as number);
        return studentId as number;
      }),
      map(studentId => {
        this.userService.getClassIdByStudentId(studentId as number)
        .subscribe(classId => {
          this.getAllFinalGrades(studentId, classId);
        });
      })
    ).subscribe();

  }

  private getMaxCountOfGrades(subjects: Array<SubjectGrade>) {
    let maxCount = 0;
    subjects.forEach(element => {
      if(element.grades?.length > maxCount) {
        maxCount = element.grades?.length
      }
    })
    return maxCount
  }

  public onGradeClick(grade: Grade) {
    if(grade !== undefined && grade !== null) {
      this.router.navigate(['/student/tasks/', grade.studentTaskId]);
    }
  }

  private getAllGrades(studentId: number) {
    this.journalService.GetAllGradesWithSubjectsForStudent(studentId)
    .subscribe(
      result => {
        this.subjectsWithGrades = result;
        this.subjectsWithGrades.map(s => s.finalGrades = []);
        this.maxCountOfGrades = this.getMaxCountOfGrades(this.subjectsWithGrades);
      }
    );
  }

  private getAllFinalGrades(studentId: number, classId: number) {
    this.journalService.GetAllFinalGradesByClassId(studentId, classId).
      subscribe(res => {
        console.log(res);
        this.subjectsWithFinalGrades = res;

        this.subjectsWithGrades.forEach(item => {
          item.finalGrades = [];
          const finalGrades = this.subjectsWithFinalGrades.filter(s => s.classSubjectId === item.classSubjectId);
          finalGrades.forEach(finalGrade => {
            item.finalGrades.push({
              gradeType: finalGrade?.gradeType,
              value: finalGrade?.grade  
              } as Grade)
          })
        });

      });
  }
}
