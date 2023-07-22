import { Task } from "./Task";

export interface User{
  userId?: string;
  name?: string;
  email?: string;
  tasks?:Task[];
}
