export interface FormFields {
  propertyName: string;
  label: string;
  defaultValue: string | undefined;
  isSelect: boolean;
  options: any[];
  type: any;
  validators: any[];
}

const defaultvalues: FormFields = {
  defaultValue: '',
  isSelect: false,
  label: '',
  type: 'text',
  options: [],
  propertyName: '',
  validators: [],
};

export const createFormField = (field: Partial<FormFields>) => {
  return {
    ...defaultvalues,
    ...field,
  };
};
