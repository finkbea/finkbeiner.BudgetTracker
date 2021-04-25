import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  users: User[] | undefined;

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {

   }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(
      u => {
        this.users = u;
        console.table(this.users);
      }
    )
  }

}
