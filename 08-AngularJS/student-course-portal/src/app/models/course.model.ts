export type GradeStatus = 'passed' | 'failed' | 'pending';
export interface Course { id: number; name: string; code: string; credits: number | null; gradeStatus: GradeStatus; }
export interface EnrollmentRequest { studentName: string; studentEmail: string; courseId: number | string; preferredSemester: 'Odd' | 'Even'; agreeToTerms: boolean; additionalCourses?: string[]; }
