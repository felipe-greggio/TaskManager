export interface Task{
 taskId?: string;
 userId?: string;
 projectId?: string;
 title?: string;
 description?: string;
 status?: EnumTaskStatus;
 dueDate?: string;
 startDate?: string;
 completedDate?: string;
}

export enum EnumTaskStatus {
  NotStarted = 0,
  Postponed = 1,
  Progress = 2,
  Done = 3
}
