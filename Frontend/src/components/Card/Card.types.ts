import { Task } from "../../model/Task";

export interface ICardsProps {
  task: Task;
  onClick: (id: string) => void;
  name: string;
}
