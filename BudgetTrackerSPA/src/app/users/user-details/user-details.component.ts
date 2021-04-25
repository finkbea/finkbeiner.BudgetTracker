import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { UserDetails } from 'src/app/models/userDetails';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  user: UserDetails | undefined;
  id?: number;

  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.getAll('id');
      this.getUserDetails();
      console.table(this.user);
    });
  }
  private getUserDetails(){
    if (this.id != null){
      this.userService.getUserById(this.id).subscribe (
        u => {this.user=u
        console.log(this.user);
      });
    }
  }

}
