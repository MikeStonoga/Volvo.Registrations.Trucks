import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface ConfirmationDialogData { 
  title: string, 
  message: string 
}

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent implements OnInit {


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: ConfirmationDialogData,
    private readonly dialogRef: MatDialogRef<ConfirmationDialogComponent>
  ) { }

  ngOnInit(): void {
  }

  public deny() {
   this.dialogRef.close({confirmed: false}); 
  }

  public confirm() {
    this.dialogRef.close({confirmed: true});
  }
  
}
