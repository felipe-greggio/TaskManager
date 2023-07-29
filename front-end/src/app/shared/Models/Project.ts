import { User } from "./User";

export interface Project
{
  projectId?: string;
  name?: string;
  status?: ProjectStatus;
  startDate?: string;
  endDate?: string;
  users?: User[];
}

export enum ProjectStatus{
  Cancelled = 0,
  Ongoing = 1,
  Delayed = 2,
  Completed = 3
}
