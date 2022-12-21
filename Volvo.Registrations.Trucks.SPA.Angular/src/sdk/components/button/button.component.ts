import { Component, Input, OnInit } from '@angular/core';

export type ButtonColor = 'primary' | 'accent' | 'warn' | 'basic'

@Component({
  selector: 'my-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() label!: string;
  @Input() iconName!: string;
  @Input() color: ButtonColor = 'primary';
  @Input() disabled: boolean = false;
  @Input() tooltip: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
