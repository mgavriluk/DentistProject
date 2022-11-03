import { Routes } from "@angular/router";

import { HomeComponent } from "./pages/home/home.component";
import { JottingsForPatientsComponent } from "./pages/jottings-for-patients/jottings-for-patients.component";
import { OrthodonticsComponent } from "./pages/orthodontics/orthodontics.component";
import { OrthopedicsComponent } from "./pages/orthopedics/orthopedics.component";
import { SurgeryComponent } from "./pages/surgery/surgery.component";
import { TherapyComponent } from "./pages/therapy/therapy.component";

export const AppRoutes: Routes = [
  {
    path: "",
    redirectTo: "home",
    pathMatch: "full",
  },
  {
    path: "home",
    component: HomeComponent,
  },
  {
    path: "orthopedics",
    component: OrthopedicsComponent,
  },
  {
    path: "surgery",
    component: SurgeryComponent,
  },
  {
    path: "therapy",
    component: TherapyComponent,
  },
  {
    path: "orthodontics",
    component: OrthodonticsComponent,
  },
  {
    path: "jottings-for-patients",
    component: JottingsForPatientsComponent,
  },
  {
    path: "**",
    redirectTo: "home",
  },
];
