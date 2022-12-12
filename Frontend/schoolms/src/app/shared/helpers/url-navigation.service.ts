import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlNavigationService {

  public openExternalUrl(url: string | undefined) {
    if(url !==undefined) {

      let urlToOpen = '';

      if (!/^http[s]?:\/\//.test(url)) {
        urlToOpen += 'http://';
      }

      urlToOpen += url;
      
      window.open(urlToOpen, '_blank')
    }
  }
}
