function main(): void {
  const projectName = "support.ai";
  console.log(welcome(projectName));
}

function welcome(name : string) {
  return "Hello, " + name.toLowerCase();
}

main();
