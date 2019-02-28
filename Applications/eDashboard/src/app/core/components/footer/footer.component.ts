import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  public appName = environment.appName;
  public appVersion = environment.appVersion;
  public currentYear = (new Date()).getFullYear();
  constructor() { }

  ngOnInit() {
  }

}
