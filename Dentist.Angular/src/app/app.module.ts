import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { ToastrModule } from "ngx-toastr";

import { SidebarModule } from "./sidebar/sidebar.module";
import { FooterModule } from "./shared/footer/footer.module";
import { NavbarModule } from "./shared/navbar/navbar.module";

import { AppComponent } from "./app.component";
import { AppRoutes } from "./app.routing";

import { OrthopedicsComponent } from "./pages/orthopedics/orthopedics.component";
import { SurgeryComponent } from "./pages/surgery/surgery.component";
import { TherapyComponent } from "./pages/therapy/therapy.component";
import { OrthodonticsComponent } from "./pages/orthodontics/orthodontics.component";
import { JottingsForPatientsComponent } from "./pages/jottings-for-patients/jottings-for-patients.component";
import { GoogleMapsModule } from "@angular/google-maps";
import { HomeComponent } from "./pages/home/home.component";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    OrthopedicsComponent,
    SurgeryComponent,
    TherapyComponent,
    OrthodonticsComponent,
    JottingsForPatientsComponent,
    HomeComponent,
  ],
  imports: [
    RouterModule.forRoot(AppRoutes, {
      useHash: true,
    }),
    BrowserAnimationsModule,
    SidebarModule,
    NavbarModule,
    ToastrModule.forRoot(),
    FooterModule,
    GoogleMapsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
