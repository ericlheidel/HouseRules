import {
  Form,
  FormFeedback,
  FormGroup,
  FormText,
  Input,
  Label,
} from "reactstrap"

export const CreateChore = () => {
  return (
    <Form>
      <FormGroup>
        <Label for="chore">Chore</Label>
        <Input />
        <FormFeedback>TEST</FormFeedback>
        <FormText>Enter a chore name</FormText>
      </FormGroup>
    </Form>
  )
}
