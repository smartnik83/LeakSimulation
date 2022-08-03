# LeakSimulation
This repo has two projects
1. GrpcLoadTest- CLient app which will send parallel request to GRPC service.
2. TestGRPCMemoryLeak- This is erver app where GRPC service is running.

In my local machine with Windows 10 OS it gets loaded with 15MB memory before serving any request. When run my client which send 10k request, memory goes upto 55MB and never get released back.
