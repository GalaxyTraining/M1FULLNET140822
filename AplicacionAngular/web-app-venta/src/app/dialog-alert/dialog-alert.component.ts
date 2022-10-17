import { Component, Inject, inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../interfaces/dialogData';

@Component({
  selector: 'app-dialog-alert',
  templateUrl: './dialog-alert.component.html',
  styleUrls: ['./dialog-alert.component.css']
})
export class DialogAlertComponent implements OnInit {

  constructor(
    public dialogRef:MatDialogRef<DialogAlertComponent>,
    @Inject(MAT_DIALOG_DATA) public data:DialogData)
   { }

  ngOnInit(): void {
  }
  onNoClick(): void{
      this.dialogRef.close();
    }
}
