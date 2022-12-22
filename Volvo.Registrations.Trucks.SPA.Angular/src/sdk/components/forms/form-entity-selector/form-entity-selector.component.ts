import { ComponentType } from '@angular/cdk/portal';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormGroupDirective, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { IdValueDTO } from 'src/app/api-access/commons/id-value-dto.model';

@Component({
  selector: 'my-form-entity-selector',
  templateUrl: './form-entity-selector.component.html',
  styleUrls: ['./form-entity-selector.component.scss']
})
export class FormEntitySelectorComponent<TEntityTableSelectorComponentType> implements OnInit {
  @Input() label!: string;
  @Input() idControlName!: string;
  @Input() nameControlName!: string;
  @Input() idInitialValue?: string;
  @Input() nameInitialValue?: string;
  @Input() disabled: boolean = false;
  @Input() readonly: boolean = true;
  @Input() tableSelectorComponentType!: ComponentType<TEntityTableSelectorComponentType>

  @Output() selected: EventEmitter<IdValueDTO> = new EventEmitter<IdValueDTO>();


  public form!: FormGroup

  constructor(
    private readonly formGroupDirective: FormGroupDirective,
    private readonly matDialog: MatDialog,
  ) {

}

  ngOnInit(): void {
    this.form = this.formGroupDirective.form;  
    this.form.addControl(this.idControlName, new FormControl({ value: this.idInitialValue, disabled: this.disabled }));
    this.form.addControl(this.nameControlName, new FormControl({ value: this.nameInitialValue, disabled: this.disabled }));
  }
  
  openToSelect() {
    this.matDialog.open(this.tableSelectorComponentType, this.form.get(this.idControlName)?.value)
    .afterClosed()
    .subscribe((result: { mustAdd: boolean, data: IdValueDTO }) => {
      if (!result || !result.mustAdd)
        return;

      this.form.get(this.idControlName)?.setValue(result.data.id);
      this.form.get(this.nameControlName)?.setValue(result.data.value);
      this.form.markAsDirty();
      this.selected.next(result.data);
    })
  }
}
