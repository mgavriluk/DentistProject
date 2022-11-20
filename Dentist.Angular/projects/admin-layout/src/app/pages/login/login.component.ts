import { Component, Input, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [
        Validators.required,
        Validators.pattern(
          /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/
        ),
      ]),
    });

    if (this.authService.isAuthenticated()) {
      this.router.navigate(["admin"]);
    }
  }

  public get isloggedIn(): boolean {
    return this.authService.isAuthenticated();
  }

  submit() {
    this.authService
      .login(this.form.get("username").value, this.form.get("password").value)
      .subscribe(
        (token) => {
          this.router.navigate(["admin"]);
        },
        (error) => {
          alert("Введен неправильный логин или пароль");
        }
      );
  }

  @Input() error: string | null;
}
