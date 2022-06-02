import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { CreateApartament, DeleteApartament } from 'src/app/+state';
import { Apartament } from 'src/app/models/apartament.model';
import { FormFields } from './config/form.fields';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit, OnChanges {
  formGroup: FormGroup;

  @Input() formFields: FormFields[] = [];
  @Input() selectedValue: any = null;

  constructor(private _fb: FormBuilder, private _store: Store) {}

  ngOnInit(): void {
    const newObj = {};
    this.formFields.forEach((field) => {
      newObj[field.propertyName] = [field.defaultValue, field.validators];
    });
    this.formGroup = this._fb.group(newObj);
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    if (
      changes.hasOwnProperty('selectedValue') &&
      changes['selectedValue'] != null
    ) {
      this.formFields.forEach((field) => {
        this.formGroup?.controls[field.propertyName].setValue(
          this.selectedValue[field.propertyName]
        );
      });
    }
  }

  printValues() {
    const apartament = {
      id_proprietar: 1,
      adresa: '',
      chirie: 0,
    };
    apartament.adresa = this.formGroup.value['adresa'];
    apartament.chirie = this.formGroup.value['chirie'];

    this._store.dispatch(CreateApartament({ apartament: apartament }));
  }

  deleteValue() {
    if (this.selectedValue === null) return;
    this._store.dispatch(
      DeleteApartament({ id: this.selectedValue.iD_Apartament })
    );
  }
}
