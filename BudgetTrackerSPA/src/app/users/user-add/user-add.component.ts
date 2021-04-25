import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { UserCreate } from 'src/app/models/userCreate';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

  userFormGroup = new FormGroup({
    email: new FormControl('',[
      Validators.required,
      Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    password: new FormControl('',[]),
    fullname: new FormControl('',[]),
    joinedon: new FormControl('',[])
  });
  

  invalidEmail: boolean = false;

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    /*var today = new Date();
    this.userFormGroup.setValue({
      joinedOn:today
    })*/
  }

  addUser(){
    console.log(this.userFormGroup.value);
    this.userService.addUser(this.userFormGroup.value).subscribe(
      (response)=>{
        this.router.navigate(['../../']);
      },
      (error) => {
        if (error){
          this.invalidEmail=true;
        }
      }
    )
  }

}
