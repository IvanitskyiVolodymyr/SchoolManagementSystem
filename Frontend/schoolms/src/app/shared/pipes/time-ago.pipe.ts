import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeAgo'
})
export class TimeAgoPipe implements PipeTransform {

  transform(value: Date): string {
    if (value) {
      const seconds = Math.floor((+new Date() - +new Date(value)) / 1000);

      if (seconds < 29)
          return 'щойно';

      const intervals: { [key: string]: number } = {
          'рік': 31536000,
          'місяць': 2592000,
          'тиждень': 604800,
          'день': 86400,
          'година': 3600,
          'хвилина': 60,
          'секунда': 1
      };
      let counter;

      for (let i in intervals) {
        counter = Math.floor(seconds / intervals[i]);
        if (counter > 0) {
          if (counter === 1) {
              return counter + ' ' + i + ' тому';
          } else {
            let time = counter;
            if(counter > 10)
              counter = this.getLastTimeDigit(counter);
            switch(i) {
              case 'рік': {
                if(counter > 1 && counter < 5)
                  i = 'роки';
                if(counter >= 5)
                  i = 'років';
                  break;
              }
              case 'місяць': {
                if(counter > 1 && counter < 5)
                  i = 'місяці';
                if(counter >= 5)
                  i = 'місяців';
                  break;
              }
              case 'тиждень': {
                if(counter > 1 && counter < 5)
                  i = 'тижні';
                if(counter >= 5)
                  i = 'тижнів';
                  break;
              }
              case 'день': {
                if(counter > 1 && counter < 5)
                  i = 'дні';
                if(counter >= 5)
                  i = 'днів';
                  break;
              }
              case 'година': {
                if(counter > 1 && counter < 5)
                  i = 'години';
                if(counter >= 5)
                  i = 'годин';
                  break;
              }
              case 'хвилина': {
                if(counter > 1 && counter < 5)
                  i = 'хвилини';
                if(counter >= 5)
                  i = 'хвилин';
                  break;
              }
              case 'секунда': {
                if(counter > 1 && counter < 5)
                  i = 'секунди';
                if(counter >= 5)
                  i = 'секунд';
                  break;
              }
            }
            return time + ' ' + i + ' тому';
          }
        }
      }
    }
    return '';

  }

  private getLastTimeDigit(num: number) {
    while(num > 10) {
      num%=10;
    }
    return num;
  }

}
