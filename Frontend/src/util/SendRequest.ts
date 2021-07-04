const header = {
  accept: "application/json",
  "Content-Type": "application/json",
};

export type SendRequestType = {
  url: string;
  method: string;
  body: BodyInit|undefined;
};

export default async function sendRequest(request: SendRequestType) {
  const requestInit: RequestInit = {
    method: request.method,
    body: request.body,
    headers: header,
  };

  const response: Response = await fetch(request.url, requestInit);
  if (!response.ok) {
    throw new Error(`Request failed with ${response.status}`);
  }
  const json = await response.json();
  return json;
}
