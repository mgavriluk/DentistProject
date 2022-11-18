import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { JwtModule } from "@auth0/angular-jwt";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./pages/login/login.component";
import { NotFoundComponent } from "./pages/not-found/not-found.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MaterialModule } from "./material/material.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { API_URL } from "./app-injection-tokens";
import { environment } from "environments/environment";
import { ACCESS_TOKEN_KEY } from "./services/auth.service";

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  declarations: [AppComponent, LoginComponent, NotFoundComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,

    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: ["localhost:7201"],
        disallowedRoutes: [],
      },
    }),
  ],
  providers: [
    {
      provide: API_URL,
      useValue: environment.dentistApi,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
