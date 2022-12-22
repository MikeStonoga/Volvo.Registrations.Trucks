import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'my-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.scss']
})
export class FormInputComponent implements OnInit {
  @Input() label!: string;
  @Input() controlName!: string;
  @Input() required: boolean = false;
  @Input() disabled: boolean = false;
  @Input() readonly: boolean = false;
  @Input() initialValue?: string;

  public form!: FormGroup;

  constructor(
    private readonly formGroupDirective: FormGroupDirective,
    private readonly changeDetector: ChangeDetectorRef,
  ) {
  }

  ngOnInit(): void {
    this.form = this.formGroupDirective.form;

    const hasFieldOnForm = !!this.form.get(this.controlName);
    if (!hasFieldOnForm) 
      this.addFieldOnForm();
  }

  private addFieldOnForm() {
    this.form.addControl(this.controlName, new FormControl({ value: this.initialValue, disabled: this.disabled }));

    if (this.required) {
      this.form.get(this.controlName)?.addValidators(Validators.required);
    }

    this.form.updateValueAndValidity();
    this.changeDetector.detectChanges();
  }
}
