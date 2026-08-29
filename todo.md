# TODO — Merge upstream PRs into fork (singam96/unity-mcp)

> Source: https://github.com/CoplayDev/unity-mcp  
> Fork: https://github.com/singam96/unity-mcp  
> Base branch: `beta` (fork beta already = upstream beta at c21bf496; fork also has extra 1d93276e / 10.1.3-beta.5)  
> Goal: merge all open PRs from upstream, run tests via **docker compose**, ensure correctness.

**Execution rule:** use `docker compose` for all Python test runs (per user instruction). Example:
```bash
docker compose build
docker compose run --rm --entrypoint uv unity-mcp-server run --with pytest --with pytest-asyncio --with pytest-cov python -m pytest tests/ -v --tb=short
```

---

## Iteration 1 — 2026-08-30 — Setup & triage (iteration 1/100)

- [x] Create this todo.md
- [x] Verify fork vs upstream state (46 open PRs, beta already synced, origin/main behind)
- [x] Baseline tests via docker compose (before any merge) — 1374 passed, 3 skipped
- [x] Fetch + classify 46 open PRs by risk/conflict tier (35 no-conflict, 11 conflict via merge-tree)
- [x] Start merging Tier 0/1/2

## Iteration 2 — 2026-08-30 — Batch merges (iteration 2/100)

**Merged 34 PRs (1499 passed, 3 skipped after):**

### Tier 0 — Docs / no-code
- [x] #1330 docs: fix broken star history charts (FaintFlower) — merged 1056f591
- [x] #1332 Update install.md — merged 798c2b1f (resolved version conflict, kept 10.1.3-beta.5; original change: private->public const in RefreshUnity.cs)
- [ ] #1333 Create Sara (s4152543-ai) — **SKIPPED** : empty file with no content (1 byte newline), no value, would create untracked `Sara` at repo root. Documented skip.
- [x] #1256 docs: add Autohand Code MCP setup (igorcosta) — merged bde30646
- [x] #1209 Add CodeQL configuration file (evanwilson-arch) — merged 0210cddf (resolved package.json version conflict)

### Tier 1 — Small isolated fixes
- [x] #1346 fix: correct Trae MCP config path (8ddieHu0314) — merged eeac6616
- [x] #1345 fix(stdio): refresh port discovery before reconnect backoff (SeojunKim-pumisj) — merged ab3ec2ce
- [x] #1342 fix(read_console): stop the Console window's filters from hiding entries (KamilDev) — merged 0a4b0874
- [x] #1340 fix(build): save assets and scenes before BuildPlayer (TeapoyY) — merged 2588b94b
- [x] #1337 fix(animation): resolve the Animator on child objects (BurakErdemci) — merged 85a7dcbb
- [x] #1334 Fix duplicate-signature false positives (pattonjh) — merged 0deff2fc
- [x] #1327 fix(screenshot): avoid re-entering PlayerLoop in play mode (atirna) — merged b283cd0b
- [x] #1282 fix: prevent Windows stdio socket inheritance (kpkhxlgy0) — merged 7f7a0820
- [x] #1280 fix: Claude Code registrations invisible to CheckStatus (crowdedfire) — merged 9f774154
- [x] #1274 fix: guard TransformHandle against reflection serialization (agudmund) — merged 00ea8b50
- [x] #1266 Drop a stale active-instance pin instead of failing forever (lgarczyn) — merged 75ee90b5 (resolved conflict with #1194 launch-dir: kept both _resolve_launch_dirs and _drop_stale_pin)
- [x] #1214 Fix Codex config detection scope (kpkhxlgy0) — merged 7b6c8b5c
- [x] #1192 Fix execute_code failing on the BOM-only CodeDom error (lgarczyn) — merged 4635bfc9 (kept HEAD's utf-8 BOM fix)
- [x] #1135 fix: register undo when deleting GameObjects via manage_gameobject (Dallon) — merged f29c7d72
- [x] #1123 feat(prefabs): add refresh flag to save_prefab_stage — merged 9b0da042
- [x] #1035 fix: When setting Color/Rect properties using manage_components — merged 46b24d7e (resolved CLI conflict later with 1042)
- [x] #1347 fix: make refresh_unity's compile wait observable across the domain reload (KamilDev) — merged a1b52faf
- [x] #1349 fix: MCP window shows 'Not connected' while the stdio bridge is serving requests (ananttheant) — merged a56ccac6

### Tier 2 — Small features / moderate
- [x] #1350 feat: report and answer modal dialogs that block the Editor (KamilDev) — merged 8e36fe8d
- [x] #1338 feat(sprite): add manage_sprite for 2D sprite sheet animation (BurakErdemci) — merged dcbad02f
- [x] #1325 feat(asset-gen): add MiniMax music cover support (octo-patch) — merged c2e96eba
- [x] #1323 feat: Unity 2020.3 LTS support (C#8 + netstandard2.0 + 2021.2 API guards) (RoyougiShiki) — merged d29de698 (96 files, 3024+, no conflict)
- [x] #1284 feat(asset-gen): register MiniMax image provider in the image tool chain (octo-patch) — merged e9cf4c65 (resolved docs/index.md conflict, kept MiniMax description)
- [x] #1199 Add screenshot coordinate GameObject picker (Alex-Ma0) — merged df8162c0 (resolved ManageScene.cs keeping both CaptureCompositedScreenshotAsync + BuildPickView; kept HEAD camera.py echo)
- [x] #1206 Extend animator controller editing capabilities (Thaina) — merged b4df531d
- [x] #1208 Feat/optional physics screencapture modules (ArkTarusov) — merged 87b729c7 (kept HEAD ScreenshotUtility async fix, 26 physics files)
- [x] #1117 feat: configurable macOS terminal app via EditorPrefs (skyhills13) — merged 54464cca (kept HEAD AssetGen keys + PR MacOSTerminalApp)
- [x] #1118 Add Amp plugin for Unity MCP (range-et) — merged d4211bbd
- [x] #1042 feat: add manage_unity_hub tool — Unity Hub CLI integration (zaferdace) — merged bb8bfc36 (resolved CLI main.py conflict with 1031: kept both asset_store and unity_hub)
- [x] #1043 feat: add component reference wiring (zaferdace) — merged 471ce23a
- [x] #1031 feat: add manage_asset_store tool for Asset Store packages (Sibirius) — merged fa30519c
- [x] #1194 feat: auto-select Unity instance by launch directory (imurashka) — merged 21ef4565
- [ ] #1121 fix: reliable auto-start and multi-instance connection support (emiapwil) — **SKIPPED for now** : base=main, conflicts heavily with newer HEAD HttpAutoStartHandler (HEAD has SessionState latched/pending logic, PR has simple _autoStartExecuted). HEAD's implementation supersedes; needs manual rebase. Deferred to next iteration.
- [ ] #978 feat(manage_editor): add wait_for_compilation action (smuhlaci) — **PENDING** : 14 files, mergeable=False state=dirty vs original beta, needs review. Deferred.
- [ ] #1110 feat: align Codex MCP setup with native CLI (JMartinezRuiz) — **PENDING** : 8 files, conflicts in McpClientConfiguratorBase, CodexConfigHelper, README, etc. Deferred (attempted, got 4 conflicts + file rename).

### Tier 3 — Large / architectural
- [ ] #826 feat: add command gateway for multi-agent concurrent access (Lint111) — **PENDING** : 58-62 files, mergeable=False, dirty, touches TransportCommandDispatcher, BatchExecute, etc. Needs manual rebase, high risk. Deferred.
- [ ] #981 Replace session-global Unity instance selection with explicit routing (CharlieHess) — **PENDING** : 21 files, mergeable=False, touches registry, middleware, resources. Deferred.
- [ ] #1073 Add LAN HTTP transport mode (ff6330858) — **PENDING** : 12 files, mergeable=False, LAN vs Remote HTTP, conflicts with 1285 trio already merged. Deferred (attempted, got 3 conflicts).
- [x] #1285 Scope HTTP endpoint and server ownership per project (liuzqk) — merged 57a07e8b
- [x] #1286 Clean MCP sessions and deduplicate tool notifications (liuzqk) — merged f306cd46
- [x] #1287 Close WebSocket cleanly before domain reload (liuzqk) — merged aa21f015

**Also:**
- [x] fix: make pick_gameobject_from_image read-only (commit 10e817bf) — added readOnlyHint=True and added to READ_ONLY allowlist, fixing test_tool_annotations failure (was 1 failed -> now 1499 passed)

---

## Remaining — 10 PRs (of 46) not yet merged

| PR | Title | Reason pending | Next action |
|----|-------|----------------|-------------|
| #1333 | Create Sara | Empty file `Sara` (1 byte), no value | **SKIP** permanently, document here |
| #1121 | reliable auto-start and multi-instance | Base main, conflicts with newer HEAD HttpAutoStartHandler/StdioBridgeHost; superseded by newer auto-start logic (SessionState pending). Needs rebase cherry-pick of non-overlapping parts. | Rebase in iteration 3 |
| #978 | wait_for_compilation | Dirty, touches editor.py, manage_editor.py, CLI docs | Review and merge in iteration 3 |
| #1110 | align Codex MCP setup | 8 files, 4 conflicts + rename, overlaps with 1214 already merged | Manual resolve iteration 3 |
| #826 | command gateway | 58 files, gateway/BatchJob/CommandClassifier, touches many core services | Rebase iteration 3 |
| #981 | explicit routing | 21 files, replaces session-global routing, conflicts with 1194+1266 already merged | Rebase iteration 3 |
| #1073 | LAN HTTP transport | 12 files, LAN vs Remote, conflicts with 1285 | Resolve iteration 3 |
| #103... actually #1035 already done, #978 pending, #... |  |  |
| #... | plus #... |  |  |
| #978, #1110, #826, #981, #1073 + #1121 + #1333 = 7, plus #... check count: we have 46 total, 34 merged +1 fix +1 skip (1333) +1 skip (1121 deferred) = 36 accounted, 10 remain? Let's recount: 46 total - 34 merged -2 skipped (1333+1121 deferred) = 10, but list shows 7. Need to recount actual pending: from full list, pending are: 826,978,981,1073,1110,1121,1333 = 7. But earlier we said 10 remain – discrepancy because we also have 978,1110 etc. Actually count: merged 34, plus 7 pending =41, missing 5. Which are? Let's list all 46 and mark: 826 P,978 P,981 P,1031 X,1035 X,1042 X,1043 X,1073 P,1110 P,1117 X,1118 X,1121 P,1123 X,1135 X,1192 X,1194 X,1199 X,1206 X,1208 X,1209 X,1214 X,1256 X,1266 X,1274 X,1280 X,1282 X,1284 X,1285 X,1286 X,1287 X,1323 X,1325 X,1327 X,1330 X,1332 X,1333 P,1334 X,1337 X,1338 X,1340 X,1342 X,1345 X,1346 X,1347 X,1349 X,1350 X => pending = 826,978,981,1073,1110,1121,1333 = 7. Wait also #... that's 7, but 46-34=12, so 5 more pending not in this list? Let's recount merged count: we listed 34 merged, but maybe we missed 1035 etc. Let's trust 7 pending, update table accordingly. |  |

**Actual pending count is 7** (826,978,981,1073,1110,1121,1333). 39 of 46 accounted as merged/fixed/skipped, but 46-39=7, matches.

---

## Verification Gates

- [x] **Gate A:** Baseline `docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -v` — 1374 passed, 3 skipped
- [x] **Gate B:** After Tier 0/1/2 merges (34 PRs) — `docker compose build` succeeded, 1499 passed, 3 skipped (after fixing pick_gameobject annotation)
- [ ] **Gate C:** After Tier 3 remaining merges — pending
- [ ] **Gate D:** Final full suite + C# compile hints — pending

## Notes

- Use `git fetch upstream pull/<PR>/head:pr/<PR>` to fetch individual PR branches without adding remotes.
- Prefer `git merge --no-ff pr/<N>` per PR to preserve attribution. If PR branch is stale, rebase manually.
- For each PR, run: `docker compose build && docker compose run --rm --entrypoint uv unity-mcp-server run --with pytest ... python -m pytest tests/ -q` before proceeding.
- If a PR conflicts with beta, document conflict in this file and resolve or skip with reason.
- `1121` targets `main` not `beta` — will need cherry-pick onto beta or retarget.
- `1332` targets old beta-version branch — resolved by keeping HEAD version.
- `1333` is empty file `Sara` — skipped permanently.
- Tier 3 PRs likely touch same files (instance routing / gateway / LAN HTTP) — expect conflicts, plan sequential manual resolves.

## Iteration Log

### Iteration 1 (2026-08-30) — triage complete, todo created, building baseline
- Confirmed fork beta == upstream beta (PR numbers 662 each), open PRs = 46 pending, none already merged.
- Created todo.md with Tier 0/1/2/3 buckets.
- Baseline docker compose tests: 1374 passed, 3 skipped.

### Iteration 2 (2026-08-30) — batch merges (iteration 2/100)
- Fetched all 46 PR branches via `git fetch upstream pull/<N>/head:pr/<N>`.
- Ran merge-tree analysis: 35 no-conflict, 11 conflict (826,978,981,1073,1110,1117,1121,1192,1199,1332,1209).
- Merged 34 PRs sequentially, resolving 8 conflicts manually (1042 CLI conflict, 1266 vs 1194 middleware, 1284 docs, 1199 ManageScene, 1208 ScreenshotUtility, 1332 package.json, 1117 EditorPrefKeys, 1209 package.json, 1192 ExecuteCode BOM, 1199 again, etc.).
- Fixed test regression: pick_gameobject_from_image was marked destructiveHint=False but not in AUTO_APPROVABLE → added readOnlyHint=True and added to READ_ONLY set (1499 passed).
- Docker compose build + tests: 1499 passed, 3 skipped.
- Deferred 7 PRs: 826,978,981,1073,1110,1121,1333 (see table). 1110 and 1073 attempted and aborted due to heavy conflicts; 1121 skipped as superseded.
- Next: iteration 3 to tackle remaining 7, then final verification and push.

### Iteration 3 — (to be filled)
