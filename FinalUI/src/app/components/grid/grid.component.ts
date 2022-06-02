import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { ColumnDefinition } from './config/column-definition';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
})
export class GridComponent implements OnInit {
  @Input() columnsDefinition: ColumnDefinition[];
  @Input() dataSource$: Observable<any[]>;
  @Output() rowClicked: EventEmitter<any> = new EventEmitter();

  definedColumns: string[] = [];

  constructor() {}

  ngOnInit(): void {
    this.columnsDefinition.forEach((c) =>
      this.definedColumns.push(c.propertyName)
    );
  }

  emitSelectedRow(element: any) {
    this.rowClicked.emit(element);
  }
}
