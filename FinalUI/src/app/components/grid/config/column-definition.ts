export interface ColumnDefinition {
  propertySelector: string;
  header: string;
  propertyName: string;
  shouldRender: 'function' | 'none';
  render: (item: any) => any;
}

const defaultValues: ColumnDefinition = {
  propertySelector: '',
  header: '',
  propertyName: '',
  shouldRender: 'none',
  render: (_) => '',
};

export const createColumnDefinition = (
  definition: Partial<ColumnDefinition>
) => ({
  ...defaultValues,
  ...definition,
});
