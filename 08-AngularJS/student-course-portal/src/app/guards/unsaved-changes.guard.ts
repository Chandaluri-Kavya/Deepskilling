import { CanDeactivateFn } from '@angular/router'; export interface DirtyForm { enrollForm: { dirty: boolean }; }
export const unsavedChangesGuard: CanDeactivateFn<DirtyForm> = component => !component.enrollForm.dirty || window.confirm('You have unsaved changes. Leave?');
