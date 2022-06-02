import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { getApartamente, getUsers } from 'src/app/+state';
import { Apartament } from 'src/app/models/apartament.model';
import { User } from 'src/app/models/user.model.ts';
import { createFormField, FormFields } from '../form/config/form.fields';
import {
  ColumnDefinition,
  createColumnDefinition,
} from '../grid/config/column-definition';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  apartamente$: Observable<Apartament[]> = of([]);
  users: User[] = [];
  selectedApartament$: BehaviorSubject<Apartament | null> = new BehaviorSubject(
    null
  );
  dysplayedColumns: ColumnDefinition[] = [
    createColumnDefinition({
      header: 'Adresa',
      propertyName: 'adresa',
      propertySelector: 'adresa',
    }),
    createColumnDefinition({
      header: 'Chirie',
      propertyName: 'chirie',
      propertySelector: 'chirie',
    }),
    createColumnDefinition({
      header: 'Proprietar',
      propertyName: 'proprietar',
      shouldRender: 'function',
      render: (elem) =>
        `${elem.proprietar.firstName} ${elem.proprietar.lastName}`,
    }),
  ];

  formFields: FormFields[] = [
    createFormField({
      defaultValue: '',
      label: 'Adresa',
      propertyName: 'adresa',
      validators: [Validators.required],
    }),
    createFormField({
      defaultValue: '',
      label: 'Chirie',
      type: 'number',
      propertyName: 'chirie',
      validators: [Validators.required, Validators.min(0)],
    }),
    createFormField({
      defaultValue: undefined,
      label: 'Proprietar',
      propertyName: 'ID_Proprietar',
      isSelect: true,
      options: this.users.map((user) => ({
        value: user.iD_User,
        text: user.firstName + ' ' + user.lastName,
      })),
    }),
  ];

  constructor(private _store: Store) {}

  ngOnInit(): void {
    this.apartamente$ = this._store
      .select(getApartamente)
      .pipe((apartamente) => apartamente);
    this._store.select(getUsers).subscribe((users) => (this.users = users));
  }

  setSelectedApartament(apartament: Apartament) {
    this.selectedApartament$.next(apartament);
  }
}
