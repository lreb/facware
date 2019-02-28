import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { Users } from 'src/app/core/models/Users';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {
  public appName = environment.appName;
  public appVersion = environment.appVersion;

  public loggedUser;
  public username = null;
  public password = null;
  public loading = false;
  public station = 'Login';

  constructor
  (
    private router: Router
  ) { }

  ngOnInit() {
  }

  public login() {
    console.log('login action');
    this.router.navigate(['dashboard']);
  }
}
