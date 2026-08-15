# Zero-Cost AI Agent in C#

A production-style AI agent built with C# and .NET using a local LLM.

No OpenAI API key.
No paid inference API.
No cloud AI bill.

The project demonstrates how to build an AI agent locally using Microsoft Agent Framework and Ollama.

## 📰 Read the Full Story

I wrote a detailed explanation of the architecture and development process on Medium:

**I Built a Zero-Cost AI Agent in C#**

👉 [Read the full article on Medium](https://medium.com/@shemeenasrawther/i-built-a-zero-cost-ai-agent-in-c-and-deployed-it-locally-e8aeef9a80a4?sk=ab636a41fc89ba0aa0ab68d75369437e)

## Architecture

```text
                    ┌─────────────────────┐
                    │     User / CLI      │
                    └──────────┬──────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │    AI Agent         │
                    │                     │
                    │ Microsoft Agent     │
                    │ Framework           │
                    └──────────┬──────────┘
                               │
                 ┌─────────────┼─────────────┐
                 │             │             │
                 ▼             ▼             ▼
            ┌─────────┐   ┌──────────┐   ┌─────────┐
            │ Tools   │   │ Memory   │   │Planning │
            └─────────┘   └──────────┘   └─────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │       Ollama        │
                    │     Local LLM       │
                    └─────────────────────┘
