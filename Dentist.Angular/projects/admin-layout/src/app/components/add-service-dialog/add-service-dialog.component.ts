import { Component, Inject, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { IDentistService } from "../../models/dentist-service";
import { AdminService } from "../../services/admin.service";

@Component({
  selector: "app-add-service-dialog",
  templateUrl: "./add-service-dialog.component.html",
  styleUrls: ["./add-service-dialog.component.css"],
})
export class AddServiceDialogComponent implements OnInit {
  form!: FormGroup;
  actionBtn: string = "Сохранить";
  serviceId: number;

  constructor(
    private formBuilder: FormBuilder,
    private adminService: AdminService,
    private dialogRef: MatDialogRef<AddServiceDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public editData: IDentistService
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [""],
      title: ["", Validators.required],
      price: ["", Validators.required],
    });

    if (this.editData) {
      this.actionBtn = "Обновить";
      this.form.controls["title"].setValue(this.editData.title);
      this.form.controls["price"].setValue(this.editData.price);
      this.form.controls["id"].setValue(this.editData.id);
    }
  }

  addDentistService() {
    if (!this.editData) {
      if (this.form.valid) {
        this.adminService.postDentistService(this.form.value).subscribe({
          next: () => {
            alert("Услуга добавлена");
            this.form.reset();
            this.dialogRef.close("save");
          },
          error: () => {
            alert("Некорректные данные");
          },
        });
      }
    } else {
      this.updateService();
    }
  }

  updateService() {
    this.adminService
      .putDentistService(this.form.value, this.serviceId)
      .subscribe({
        next: () => {
          alert("Данные обновлены");
          this.form.reset();
          this.dialogRef.close("update");
        },
        error: () => {
          alert("Ошибка");
        },
      });
  }
}
