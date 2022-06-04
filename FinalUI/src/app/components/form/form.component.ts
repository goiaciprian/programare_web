import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { CreateApartament, DeleteApartament } from 'src/app/+state';
import { Apartament } from 'src/app/models/apartament.model';
import { ApartamentDTO } from 'src/app/models/apartamentdto.model';
import { ApartamenteService } from 'src/app/services/apartamente.service';
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
  value: BehaviorSubject<any> = new BehaviorSubject(null);
  hasValue: boolean = false;

  constructor(private _fb: FormBuilder, private _store: Store) {}

  ngOnInit(): void {
    const newObj = {};
    this.formFields.forEach((field) => {
      newObj[field.propertyName] = [field.defaultValue, field.validators];
    });
    this.formGroup = this._fb.group(newObj);

    this.value.subscribe((value) =>
      this.formFields.forEach((field) => {
        this.hasValue = value != null;
        this.formGroup?.controls[field.propertyName].setValue(
          this.hasValue
            ? this.selectedValue[field.propertyName]
            : field.defaultValue
        );
      })
    );
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.hasOwnProperty('selectedValue')) {
      this.value.next(changes['selectedValue'].currentValue);
    }
  }

  printValues() {
    if (!this.formGroup.valid) return;

    const apartament = {
      id_proprietar: 1,
      adresa: '',
      chirie: 0,
    };
    apartament.adresa = this.formGroup.value['adresa'];
    apartament.chirie = this.formGroup.value['chirie'];

    this._store.dispatch(
      CreateApartament({
        apartament: apartament,
      })
    );
    this.reset();
  }

  deleteValue() {
    if (this.selectedValue === null) return;
    this._store.dispatch(
      DeleteApartament({ id: this.selectedValue.iD_Apartament })
    );
    this.reset();
  }

  reset() {
    this.value.next(null);
  }
}
