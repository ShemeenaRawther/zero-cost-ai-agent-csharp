# 🤖 Zero-Cost AI Agent in C#

> **A production-style AI agent built with C# and .NET, powered by a local LLM — without paying for an AI API.**

This project demonstrates how to build an AI agent locally using **C#**, **.NET**, **Microsoft Agent Framework**, and **Ollama**.

Instead of sending every request to a paid cloud AI provider, the agent runs an LLM locally on your machine.

**No OpenAI API key. No per-request charges. No cloud inference bill.**

---

## 📖 Read the Full Story

I documented the architecture, design decisions, and development journey in my Medium article:

### **I Built a Zero-Cost AI Agent in C#**

👉 **[Read the full article on Medium](https://medium.com/@shemeenasrawther/i-built-a-zero-cost-ai-agent-in-c-and-deployed-it-locally-e8aeef9a80a4?sk=ab636a41fc89ba0aa0ab68d75369437e)**

The article explains how the different pieces fit together and why running an AI agent locally can be an interesting option for developers.

---

## 🧠 What Are We Building?

The goal is to build a local AI agent capable of:

* Understanding natural-language requests
* Reasoning about tasks
* Calling tools
* Interacting with a local LLM
* Executing application logic
* Running without a paid AI API

The high-level architecture looks like this:

```text
                         ┌─────────────────────┐
                         │       User          │
                         │   Natural Language  │
                         └──────────┬──────────┘
                                    │
                                    ▼
                         ┌─────────────────────┐
                         │     AI Agent        │
                         │                     │
                         │ Microsoft Agent     │
                         │ Framework           │
                         └──────────┬──────────┘
                                    │
                 ┌──────────────────┼──────────────────┐
                 │                  │                  │
                 ▼                  ▼                  ▼
          ┌────────────┐     ┌────────────┐     ┌────────────┐
          │   Tools    │     │   Memory   │     │  Planning  │
          └────────────┘     └────────────┘     └────────────┘
                                    │
                                    ▼
                         ┌─────────────────────┐
                         │       Ollama        │
                         │                     │
                         │     Local LLM       │
                         └─────────────────────┘
                                    │
                                    ▼
                         ┌─────────────────────┐
                         │   Local Hardware    │
                         │     CPU / GPU       │
                         └─────────────────────┘
```

---

## ✨ Why "Zero-Cost"?

Traditional AI applications often depend on cloud APIs.

For example:

```text
Application
     │
     ▼
Cloud API
     │
     ▼
LLM Provider
     │
     ▼
API Usage Cost
```

This project takes a different approach:

```text
Application
     │
     ▼
AI Agent
     │
     ▼
Ollama
     │
     ▼
Local LLM
     │
     ▼
Your Computer
```

The model runs locally, so there is no per-request API charge.

> **Note:** "Zero-cost" refers to inference/API usage. You still need hardware capable of running the selected model, and electricity/storage have real-world costs.

---

# 🛠️ Technology Stack

| Technology                    | Purpose                            |
| ----------------------------- | ---------------------------------- |
| **C#**                        | Application development            |
| **.NET**                      | Runtime and application framework  |
| **Microsoft Agent Framework** | Agent orchestration                |
| **Ollama**                    | Local LLM runtime                  |
| **Local LLM**                 | AI inference                       |
| **GitHub**                    | Source control and project hosting |

---

# 📋 Prerequisites

Before running the project, install:

### .NET

Install the appropriate .NET SDK for this project.

```bash
dotnet --version
```

### Ollama

Install Ollama on your machine.

After installation, verify:

```bash
ollama --version
```

### Local LLM

Pull the model used by this project:

```bash
ollama pull YOUR_MODEL_NAME
```

Then verify that the model is available:

```bash
ollama list
```

---

# 🚀 Getting Started

## 1. Clone the repository

```bash
git clone https://github.com/YOUR_GITHUB_USERNAME/zero-cost-ai-agent-csharp.git
```

Move into the project:

```bash
cd zero-cost-ai-agent-csharp
```

---

## 2. Restore dependencies

```bash
dotnet restore
```

---

## 3. Build the project

```bash
dotnet build
```

---

## 4. Start Ollama

Make sure Ollama is running locally.

Depending on your operating system, Ollama may already be running in the background.

You can verify that your model is available:

```bash
ollama list
```

---

## 5. Run the AI Agent

```bash
dotnet run
```

You should now be able to interact with the agent from your application.

Example:

```text
You: What can you do?

Agent: I can understand your request and use the tools
       available to me to complete the task.
```

---

# 🧩 Project Structure

```text
zero-cost-ai-agent-csharp/
│
├── src/
│   └── ZeroCostAiAgent/
│       │
│       ├── Agents/
│       │   └── ...
│       │
│       ├── Tools/
│       │   └── ...
│       │
│       ├── Models/
│       │   └── ...
│       │
│       ├── Services/
│       │   └── ...
│       │
│       └── Program.cs
│
├── docs/
│   ├── architecture.png
│   └── architecture.md
│
├── tests/
│   └── ZeroCostAiAgent.Tests/
│
├── .gitignore
├── LICENSE
├── README.md
└── ZeroCostAiAgent.sln
```

> The actual structure may evolve as the project grows.

---

# 🔧 How It Works

The application follows a simple agent flow:

```text
             User Request
                   │
                   ▼
          ┌─────────────────┐
          │    AI Agent     │
          └────────┬────────┘
                   │
                   ▼
          ┌─────────────────┐
          │  Local LLM      │
          │    Ollama       │
          └────────┬────────┘
                   │
             ┌─────┴─────┐
             │           │
             ▼           ▼
          Response      Tool
                         Call
                           │
                           ▼
                    Application Logic
                           │
                           ▼
                       Tool Result
                           │
                           ▼
                       AI Agent
                           │
                           ▼
                      Final Answer
```

The important idea is that the **agent is not the same thing as the LLM**.

The LLM provides the intelligence required to interpret and reason about the request.

The agent provides the surrounding orchestration:

* Instructions
* Tools
* Context
* Execution
* Application logic
* Interaction with external systems

---

# 🧰 Agent Tools

One of the most important concepts demonstrated by this project is **tool calling**.

An AI agent becomes much more useful when it can interact with software instead of simply generating text.

For example:

```text
User
 │
 │ "What's the current status?"
 ▼
AI Agent
 │
 │ decides a tool is required
 ▼
Tool
 │
 │ executes application logic
 ▼
Tool Result
 │
 ▼
AI Agent
 │
 ▼
Natural-language response
```

You can extend this project with tools such as:

* Calculator
* File search
* Weather
* Database queries
* REST APIs
* Internal business services
* Document search
* RAG
* Custom application functions

---

# 🧠 Local AI Architecture

The key difference between this project and a traditional cloud-based AI application is where inference happens.

### Traditional architecture

```text
┌──────────────┐
│ C# App       │
└──────┬───────┘
       │
       │ HTTPS
       ▼
┌──────────────┐
│ Cloud API    │
└──────┬───────┘
       │
       ▼
┌──────────────┐
│ Cloud LLM    │
└──────────────┘
```

### This project

```text
┌──────────────┐
│ C# App       │
└──────┬───────┘
       │
       ▼
┌──────────────┐
│ AI Agent     │
└──────┬───────┘
       │
       ▼
┌──────────────┐
│ Ollama       │
└──────┬───────┘
       │
       ▼
┌──────────────┐
│ Local LLM     │
└──────────────┘
```

This architecture can be particularly interesting for:

* Experimentation
* Learning
* Prototyping
* Privacy-sensitive workloads
* Offline development
* Developer environments
* Local AI experimentation

---

# 🔐 Privacy

Because the model runs locally, prompts and responses do not need to be sent to a third-party inference API.

That makes local inference an interesting option when experimenting with:

* Private documents
* Internal prototypes
* Sensitive development data
* Offline workflows

However, privacy depends on the rest of your application architecture. External tools, APIs, telemetry, or other services can still transmit data.

---

# ⚡ Performance

Local AI performance depends heavily on your hardware and model.

Important factors include:

* GPU VRAM
* GPU architecture
* System RAM
* CPU
* Model size
* Quantization
* Context length
* Concurrent requests

A smaller model may provide significantly better local performance than a large model on limited hardware.

---

# 💰 Cost Model

| Component       | Cost                           |
| --------------- | ------------------------------ |
| C# / .NET       | Free                           |
| Ollama          | Free                           |
| Local model     | Typically free to download/use |
| API requests    | **$0**                         |
| Cloud inference | **$0**                         |
| Hardware        | Existing hardware required     |
| Electricity     | Real-world cost                |

The main advantage is eliminating recurring **API inference costs** during development and experimentation.

---

# 🧪 Example Use Cases

This architecture can be extended into much larger applications.

### Developer Assistant

```text
Developer
    │
    ▼
AI Agent
    │
    ├── Search code
    ├── Read files
    ├── Analyze errors
    └── Generate solution
```

### Local RAG Application

```text
Documents
    │
    ▼
Embedding / Index
    │
    ▼
Retriever
    │
    ▼
AI Agent
    │
    ▼
Local LLM
```

### Multi-Agent System

```text
                 ┌──────────────┐
                 │ Coordinator  │
                 └──────┬───────┘
                        │
             ┌──────────┼──────────┐
             ▼          ▼          ▼
         Researcher  Developer   Reviewer
             │          │          │
             └──────────┼──────────┘
                        ▼
                  Final Response
```

---

# 📚 What You Will Learn

By exploring this repository, you can learn how to:

* Build an AI application using C#
* Work with local LLMs
* Run models through Ollama
* Build an AI agent
* Connect an agent to tools
* Separate agent orchestration from model inference
* Experiment with local AI without API charges
* Design an extensible agent architecture

---

# 🔮 Possible Future Improvements

This project is intentionally designed so it can evolve.

Potential future additions include:

* [ ] Persistent agent memory
* [ ] RAG pipeline
* [ ] Vector database integration
* [ ] Multiple tools
* [ ] Web search tool
* [ ] File-system tool
* [ ] Multi-agent orchestration
* [ ] Streaming responses
* [ ] Web UI
* [ ] ASP.NET Core API
* [ ] Docker support
* [ ] Observability and logging
* [ ] Evaluation framework
* [ ] Production deployment

---

# 📖 Related Articles

### Medium

**I Built a Zero-Cost AI Agent in C#**

👉 [Read the complete article](https://medium.com/@shemeenasrawther/i-built-a-zero-cost-ai-agent-in-c-and-deployed-it-locally-e8aeef9a80a4?sk=ab636a41fc89ba0aa0ab68d75369437e)

More articles about C#, .NET, AI agents, and local AI will be added as the project evolves.

---

# 🤝 Contributing

Contributions, ideas, improvements, and experiments are welcome.

If you find a bug or have an idea for improving the agent:

1. Open an issue.
2. Describe the problem or proposed improvement.
3. Provide reproduction steps where applicable.
4. Submit a pull request if you have an implementation.

---

# ⭐ Support the Project

If you find this project useful:

⭐ **Star the repository**

🐛 **Open an issue**

💡 **Share an idea**

🔀 **Submit a pull request**

And if you found the project through the Medium article, consider sharing the article with other .NET developers interested in AI.

---

# 📄 License

This project is licensed under the **MIT License**.

See the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Shemeena Rawther**

.NET / C# Developer | AI & Cloud Engineering

* GitHub: [@ShemeenaRawther](https://github.com/ShemeenaRawther)
* Medium: [@shemeenasrawther](https://medium.com/@shemeenasrawther)

---

> **The interesting part isn't just running an LLM locally.**
>
> **It's what happens when you put an agent around it.**
