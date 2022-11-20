import { Component, Inject, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { IClient } from "../../models/client";
import { AdminService } from "../../services/admin.service";

@Component({
  selector: "app-add-client-dialog",
  templateUrl: "./add-client-dialog.component.html",
  styleUrls: ["./add-client-dialog.component.css"],
})
export class AddClientDialogComponent {
  form!: FormGroup;
  actionBtn: string = "Сохранить";
  clientId: number;

  constructor(
    private formBuilder: FormBuilder,
    private adminService: AdminService,
    private dialogRef: MatDialogRef<AddClientDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public editData: IClient
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [""],
      firstName: ["", Validators.required],
      lastName: ["", Validators.required],
      age: ["", Validators.min(0), Validators.max(100)],
    });

    if (this.editData) {
      this.actionBtn = "Обновить";
      this.form.controls["firstName"].setValue(this.editData.firstName);
      this.form.controls["lastName"].setValue(this.editData.lastName);
      this.form.controls["age"].setValue(this.editData.age);
    }
  }

  addClient() {
    if (!this.editData) {
      if (this.form.valid) {
        this.adminService.postClient(this.form.value).subscribe({
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
      this.updateClient();
    }
  }

  updateClient() {
    this.adminService.putClient(this.form.value, this.clientId).subscribe({
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
